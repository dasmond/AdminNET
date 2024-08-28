let BASE_URL
//开发环境中
if (process.env.NODE_ENV === 'development') {
  // 开发环境
  BASE_URL = 'http://localhost:5005'  //开发环境请求地址
} else {
  // 生产环境
  BASE_URL = 'https://xxxx'  //生成环境请求地址
}

let PublicKey = '0484C7466D950E120E5ECE5DD85D0C90EAA85081A3A2BD7C57AE6DC822EFCCBD66620C67B0103FC8DD280E36C3B282977B722AAEC3C56518EDCEBAFB72C5A05312'  //公钥
 
export {
  BASE_URL,
  PublicKey
}