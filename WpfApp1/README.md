# AES Encryption and Decryption Demo

This is a simple C# WPF application that demonstrates encryption and decryption using the Advanced Encryption Standard (AES) algorithm. The application allows users to encrypt text data with a password, validate password complexity, decrypt the data using the same password, and save the encrypted data to a text file.


## Usage

1. Enter the text you want to encrypt in the "Text to Encrypt" textbox.

2. Enter a password that meets the specified complexity requirements in the "Password" textbox.

3. Click the "Encrypt" button to encrypt the text using AES encryption and PBKDF2 key derivation.

4. The base64-encoded encrypted data will appear in the "Encrypted Text" textbox.

5. To decrypt the encrypted data, enter the same password in the "Password" textbox and click the "Decrypt" button.

6. The decrypted text will be displayed in the "Decrypted Text" textbox.

7. You can also save the encrypted data to a text file by clicking the "Save" button.

## Password Complexity Requirements

- At least 8 characters in length
- Contains at least one uppercase letter
- Contains at least one lowercase letter
- Contains at least one numeric digit
- Contains at least one special character (e.g., !@#$%^&*()_+=[]{};:<>|./?,-)

## Security Considerations

- This is a demo application and should not be used for production without thorough security reviews.
- Ensure proper key management practices when working with encryption and decryption.
- Be cautious when handling sensitive data and passwords.
