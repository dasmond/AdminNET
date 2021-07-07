import { useI18n } from '/@/hooks/web/useI18n';

export const assertParamExists = function (functionName: string, paramName: string, paramValue: unknown) {
    const { t } = useI18n();
    if (paramValue === null || paramValue === undefined) {
        throw new Error(t('sys.api.assertParamExists', [paramName, functionName]));
    }
}
