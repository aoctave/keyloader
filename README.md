## Keyloader

Test tool for Yubikey PIV application

Functions: 
- Load ECC key to PIV slot 9E
- Create signature with key in slot 9E
- Authenticate with management key
- Check user PIN
- Check serial
- Benchmark by timing 1000 ECC signatures

Limits and special considerations: 
- Key is repeated in plaintext in log, not for production key material
- Benchmark will attempt to authenticate with default PIN 123456 (0x313233343536)
- PIN is actually not needed for signatures, policy is hardcoded as PIN not required
- Unhandled exceptions may occur if device is disconnected and reconnected
