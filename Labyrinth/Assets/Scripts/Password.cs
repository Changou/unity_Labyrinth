using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{

    // 키로 사용하기 위한 암호 정의
    private static readonly string PASSWORD = "AnytimeAnywhereAnyoneAnythingAnyhow";
    //3ds1s334e4dcc7c4yz4554e732983h
    // 인증키 정의
    private static readonly string KEY = PASSWORD.Substring(0, 128 / 8);

    private string str1;

    public InputField passwordInput;
    public Button passwordBtn;
    public Text resultText;
    public GameObject text;

    public bool istrue;

    private string pwOrigin;
    void Awake()
    {
        string str = "잠금이 해제되었습니다.";
        Debug.Log("plain : " + str);

        str1 = AESEncrypt128(str);
        Debug.Log("AES128 encrypted : " + str1);
    }

    // 암호화
    public static string AESEncrypt128(string plain)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plain);

        RijndaelManaged myRijndael = new RijndaelManaged();
        myRijndael.Mode = CipherMode.CBC;
        myRijndael.Padding = PaddingMode.PKCS7;
        myRijndael.KeySize = 128;

        MemoryStream memoryStream = new MemoryStream();

        ICryptoTransform encryptor = myRijndael.CreateEncryptor(Encoding.UTF8.GetBytes(KEY), Encoding.UTF8.GetBytes(KEY));

        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();

        byte[] encryptBytes = memoryStream.ToArray();

        string encryptString = Convert.ToBase64String(encryptBytes);

        cryptoStream.Close();
        memoryStream.Close();

        return encryptString;
    }

    // 복호화
    public static string AESDecrypt128(string encrypt, string passwordKey)
    {
        try
        {
            byte[] encryptBytes = Convert.FromBase64String(encrypt);

            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.Mode = CipherMode.CBC;
            myRijndael.Padding = PaddingMode.PKCS7;
            myRijndael.KeySize = 128;

            MemoryStream memoryStream = new MemoryStream(encryptBytes);

            ICryptoTransform decryptor = myRijndael.CreateDecryptor(Encoding.UTF8.GetBytes(passwordKey), Encoding.UTF8.GetBytes(passwordKey));

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainBytes = new byte[encryptBytes.Length];

            int plainCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);   //문제발생

            string plainString = Encoding.UTF8.GetString(plainBytes, 0, plainCount);

            cryptoStream.Close();
            memoryStream.Close();
            
            return plainString;
        }
        catch (CryptographicException ex)
        {
            
            Debug.LogError("복호화 오류: " + ex.Message);
            return null;
            
        }
    }

    // Update is called once per frame
    public void ClickBtn()
    {
        passwordBtn.gameObject.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        text.SetActive(false);
        resultText.gameObject.SetActive(true);

        string password = passwordInput.text;
        string KEY2 = password.Substring(0, 128 / 8);
        string str2 = AESDecrypt128(str1, KEY2);

        if(str2 == null)
        {
            str2 = "비밀번호가 잘못되었습니다.";
            istrue = false;
        }
        resultText.text = str2;
        Debug.Log("AES128 decrypted : " + str2);
    }
}
