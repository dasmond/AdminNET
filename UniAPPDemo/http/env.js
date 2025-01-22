// 常量定义
const DEVELOPMENT = "development";
const PRODUCTION = "production";

// 环境配置
const config = {
  [DEVELOPMENT]: {
    BASE_URL: "http://localhost:5005/",
    account: "superadmin",
    password: "123456",
  },
  [PRODUCTION]: {
    BASE_URL: "https://xxxx",
    account: "",
    password: "",
  },
};

// 当前环境
const currentEnv = process.env.NODE_ENV || DEVELOPMENT;

// 公钥
const PublicKey =
  "0484C7466D950E120E5ECE5DD85D0C90EAA85081A3A2BD7C57AE6DC822EFCCBD66620C67B0103FC8DD280E36C3B282977B722AAEC3C56518EDCEBAFB72C5A05312";

// 默认租户ID
const defaultTenantId = "1300000000001";

// 导出配置
export const { BASE_URL, account, password } = config[currentEnv];
export { PublicKey, defaultTenantId };
