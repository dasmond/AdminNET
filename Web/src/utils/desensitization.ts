// 姓名脱敏
export const newName = (value: string) => {
    value = value.replace(/^\s+|\s+$/g, "");
    if (value && value.length == 2) {
        return value.replace(/^(.{1}).*(.{1})$/, "$1*");
    } else if (value && value.length > 2) {
        return value.replace(/^(.{1}).*(.{1})$/, "$1*$2");
    } else {
        return value;
    }
}

// 姓名多个脱敏
export const newNames = (value: string) => {
    const names: string[] = [];
    value.split(",").forEach((item) => {
        item = item.replace(/^\s+|\s+$/g, "");
        if (item && item.length == 2) {
            names.push(item.replace(/^(.{1}).*(.{1})$/, "$1*"));
        } else if (item && item.length > 2) {
            names.push(item.replace(/^(.{1}).*(.{1})$/, "$1*$2"));
        } else {
            names.push(item);
        }
    });
    return names.join("、");
}

// 电话脱敏
export const newPhone = (value: string) => {
    return value.replace(/^(.{3}).*(.{4})$/, "$1**$2");
}

// 身份证号脱敏
export const newIdCard = (value: string) => {
    return value.replace(/^(.{3}).*(.{4})$/, "$1****$2");
}

// 拼音脱敏
export const newPinyin = (value: string) => {
    return value.replace(/^(.{2}).*(.{2})$/, "$1****$2");
}

// 证件号脱敏
export const newCard = (value: string) => {
    return value.replace(/^(.{2}).*(.{2})$/, "$1****$2");
}

// 邮箱脱敏
export const newEmail = (value: string) => {
    return value.replace(/^(.{3}).*(.{5})$/, "$1****$2");
}

// 邮编脱敏
export const newZipCode = (value: string) => {
    return value.replace(/^(.{2}).*(.{2})$/, "$1**$2");
}

// 自定义脱敏
export const newValue = (value: string, before: number, after: number) => {
    if (!value) { return ''; }
    const regItem = '[\u4e00-\u9fa5a-zA-Z0-9]';
    const regExp = `(${regItem}{${before}})${regItem}*(${regItem}{${after}})`;
    const reg = new RegExp(regExp);
    return value.replace(reg, '$1*****$2');
}