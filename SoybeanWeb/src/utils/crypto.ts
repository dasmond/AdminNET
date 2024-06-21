/*
 * @Author: 490912587@qq.com
 * @Date: 2024-01-05 15:31:29
 * @LastEditors: 490912587@qq.com
 * @LastEditTime: 2024-06-19 15:05:00
 * @FilePath: \WebSoybean\src\utils\crypto.ts
 * @Description: 
 */
import CryptoJS from 'crypto-js';

const CryptoSecret = '__CryptoJS_Secret__';
//加密公钥
export const publicKey = `04851D329AA3E38C2E7670AFE70E6E70E92F8769CA27C8766B12209A0FFBA4493B603EF7A0B9B1E16F0E8930C0406EA0B179B68DF28E25334BDEC4AE76D907E9E9`;
/**
 * 加密数据
 * @param data - 数据
 */
export function encrypt(data: any) {
  const newData = JSON.stringify(data);
  return CryptoJS.AES.encrypt(newData, CryptoSecret).toString();
}

/**
 * 解密数据
 * @param cipherText - 密文
 */
export function decrypt(cipherText: string) {
  const bytes = CryptoJS.AES.decrypt(cipherText, CryptoSecret);
  const originalText = bytes.toString(CryptoJS.enc.Utf8);
  if (originalText) {
    return JSON.parse(originalText);
  }
  return null;
}
