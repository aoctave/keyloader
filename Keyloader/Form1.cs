using System.Collections.Generic;
using System.Windows.Forms;
using Yubico.YubiKey;
using Yubico.YubiKey.Piv;

namespace Keyloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        IYubiKeyDevice ykey;
        PivSession pivSession;

        private void button1_Click(object sender, EventArgs e)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            ykey = GetFirstKey();

            if (ykey is null)
            {
                textBox1.AppendText("No key selected\r\n");
            }
            else
            {
                textBox1.AppendText("Key selected\r\n");
                button2.Enabled = true;
            }

            watch.Stop();
            textBox1.AppendText(" * " + watch.ElapsedMilliseconds.ToString() + "ms\r\n");

        }

        IYubiKeyDevice? GetFirstKey()
        {
            // IEnumerable<IYubiKeyDevice> list = YubiKeyDevice.FindAll();
            IEnumerable<IYubiKeyDevice> list = YubiKeyDevice.FindByTransport(Transport.UsbSmartCard);

            textBox1.AppendText(list.Count().ToString() + " devices found\r\n");

            if (list.Count() == 0)
            {
                return null;
            }
            else
            {
                return list.First();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            // using var pivSession = new PivSession(ykey);
            try
            {
                pivSession = new PivSession(ykey);
            }
            catch (Exception ex)
            {
                textBox1.AppendText("Connection exception: " + ex.Message + "\r\n");
            }

            watch.Stop();
            textBox1.AppendText("Connected PIV session.\r\n * " + watch.ElapsedMilliseconds.ToString() + "ms\r\n");

            button3.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            checkBox1.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {


            Yubico.YubiKey.Piv.Commands.GetSerialNumberCommand serialCommand = new Yubico.YubiKey.Piv.Commands.GetSerialNumberCommand();

            Yubico.YubiKey.Piv.Commands.GetSerialNumberResponse serialResponse = pivSession.Connection.SendCommand(serialCommand);

            if (serialResponse.Status == ResponseStatus.Success)
            {
                // int serialNum = serialResponse.GetData();
                textBox1.AppendText("Serial " + serialResponse.GetData().ToString() + "\r\n");
            }
            else
            {
                textBox1.AppendText("Couldn't get serial number\r\n");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                Byte[] keyArray = Convert.FromHexString(textBox2.Text);
                textBox1.AppendText("Hex convert ok, size: " + keyArray.Length.ToString() + ", key: " + Convert.ToBase64String(keyArray) + "\r\n");

                if (keyArray != null && (keyArray.Length == 48 || keyArray.Length == 32))
                {
                    tryLoadKey(keyArray, pivSession);
                    textBox1.AppendText("Sent key\r\n");
                }
                else
                {
                    textBox1.AppendText("Must be 32 or 48 bytes\r\n");
                }

            }
            catch (Exception ex) 
            {
                textBox1.AppendText("Error: " + ex.Message + "\r\n");
            }

        }

        public static bool tryLoadKey(Byte[] keyArray, PivSession pivSession)
        {

            PivEccPrivateKey privateKey = new PivEccPrivateKey(keyArray);
            var dummyDelegate = new DummyKeyCollector();
            pivSession.KeyCollector = dummyDelegate.KeyCollectorDelegate;
            pivSession.ImportPrivateKey(0x9E, privateKey, PivPinPolicy.Never, PivTouchPolicy.Never);

            return false;
        }

        public static Byte[] trySign(Byte slot, Byte[] dataToSign, PivSession pivSession)
        {

            var dummyDelegate = new DummyKeyCollector();
            pivSession.KeyCollector = dummyDelegate.KeyCollectorDelegate;
            Byte[] signature = pivSession.Sign(slot, dataToSign); ;

            return signature;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Byte[] defaultManagementKey = Convert.FromHexString("010203040506070801020304050607080102030405060708");

            try
            {
                Byte[] managementKey = Convert.FromHexString(textBox3.Text);
                // bool authResult = pivSession.TryAuthenticateManagementKey(defaultManagementKey);
                bool authResult = pivSession.TryAuthenticateManagementKey(managementKey);

                if (authResult)
                {
                    textBox1.AppendText("Success.\r\n");
                }
                else
                {
                    textBox1.AppendText("Authorization failed.\r\n");
                }

            }
            catch (Exception ex)
            {
                textBox1.AppendText("Error: management key format problem. " + ex.Message + "\r\n");
            }

        }

        public class DummyKeyCollector
        {
            public DummyKeyCollector()
            {
            }
            public bool KeyCollectorDelegate(KeyEntryData keyEntryData)
            {
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Benchmark, uses default PIN

            Byte[] dataToSign = Convert.FromHexString("000102030405060708090a0b0c0d0e0f000102030405060708090a0b0c0d0e0f");
            Byte[] defaultPin = Convert.FromHexString("313233343536");

            bool pinResult = pivSession.TryVerifyPin(defaultPin, out int? retriesRemaining);
            textBox1.AppendText("PIN verify result: " + pinResult.ToString() + ", " + retriesRemaining.ToString() + " tries remaining.\r\n");

            if (pinResult)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                textBox1.AppendText("Benchmark signing 1000 transactions...\r\n");

                // Byte[] signature = trySign(dataToSign, pivSession);
                // textBox1.AppendText("Signature (b64): " + Convert.ToBase64String(signature));

                for (int i = 0; i <= 1000; i++)
                {
                    trySign(0x9E, dataToSign, pivSession);
                }

                watch.Stop();
                textBox1.AppendText(" * " + watch.ElapsedMilliseconds.ToString() + "ms\r\n");

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
            // button4.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] dataToSign = Convert.FromHexString(textBox5.Text);
                Byte[] signature = trySign(0x9E, dataToSign, pivSession);
                textBox1.AppendText("Data: " + Convert.ToBase64String(dataToSign) + "\r\n");
                textBox1.AppendText("Signature: " + Convert.ToBase64String(signature) + "\r\n");
            }
            catch (Exception ex)
            {
                textBox1.AppendText("Error: " + ex.Message + "\r\n");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                Byte[] defaultPin = Convert.FromHexString(textBox4.Text);
                bool pinResult = pivSession.TryVerifyPin(defaultPin, out int? retriesRemaining);
                textBox1.AppendText("PIN verify result: " + pinResult.ToString() + ", " + retriesRemaining.ToString() + " tries remaining.\r\n");
            }
            catch (Exception ex)
            {
                textBox1.AppendText("Error: " + ex.Message + "\r\n");
            }
            
        }
    }

}
