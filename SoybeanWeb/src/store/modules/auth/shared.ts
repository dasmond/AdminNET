import { localStg } from '@/utils/storage';
import { accessTokenKey, refreshAccessTokenKey } from "@/utils/request"
/** Get token */
export function getToken() {
  return localStg.get(accessTokenKey) || '';
}

/** Clear auth storage */
export function clearAuthStorage() {
  localStg.remove(accessTokenKey);
  localStg.remove(refreshAccessTokenKey);
}
