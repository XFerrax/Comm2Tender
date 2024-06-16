import * as helpers from '~/utils/helpers'

export function requiredRule(value: any) : boolean | string {
  return !!value || 'Обязательное поле'
}


export function emailRule(value: string) : boolean | string
{
  const pattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/i
  return !value || pattern.test(value) || 'Проверьте правильность заполнения'
}

export function dateRule(value: string, type?: helpers.DateType) 
 {
  if (!type) {
    type = helpers.DateType.date
  }
  return !value || helpers.convertDateStringToISOString(value, type).length > 0 || 'Некорректная дата'
}

export function lengthRule(value: string, message: string, rule?: helpers.ILengthRule) {
  if (!rule) {
    return 'Неправильно установлено правило проверки';
  }

  const length = value.length;
  const min = rule.min;
  const max = rule.max;

  if (!message) {
    message =
      'Количество символов должно быть ' +
      (min !== undefined && max !== undefined
        ? min === max
          ? `${min}`
          : `от ${min} до ${max}`
        : min !== undefined
        ? `не менее ${min}`
        : `не более ${max}`);
  }

  if (!value) {
    return true; // пустое значение допускается, так как обязательность проверяется required
  }

  if ((min !== undefined && length < min) || (max !== undefined && length > max)) {
    return message;
  }

  return true;
}

// export function phone(value, message) {
//   return length(value, { min: 16, max: 16 }, message)
// }

export function intRule(value: string|number, short: boolean, rule?: helpers.ILengthRule) {
  if (!rule) {
    rule = { min: undefined, max: undefined }
  }
  const min = rule.min
  const max = rule.max

  const message =
    (short ? '' : 'Требуется целое число ') +
    (min !== undefined && max !== undefined
      ? min === max
        ? `${min}`
        : `от ${min} до ${max}`
      : min !== undefined
      ? `не менее ${min}`
      : `не более ${max}`)

  // https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Global_Objects/parseInt#Более_строгая_функция_интерпретации
  const isInteger = /^(-|\+)?([0-9]+|Infinity)$/.test(value as string)
  const length = value == null ? 0 : (value as string).length
  value = parseInt(value as string)

  return (
    length === 0 || // отсутствующее значение допускается, так как обязательность проверяется required
    (isInteger && isNaN(value) === false && (min === undefined || value >= min) && (max === undefined || value <= max)) ||
    message
  )
}

export function floatRule({ value, rule = { min: undefined, max: undefined }, short = false, text = 'Требуется число', suffix = '' }: FloatValidatorOptions): boolean | string {
  if (typeof value === 'string') {
    value = value.replace(',', '.');
  }

  const min = rule.min;
  const max = rule.max;

  const message =
    (short ? '' : `${text} `) +
    (min !== undefined && max !== undefined
      ? min === max
        ? `${min}`
        : `от ${min} до ${max}`
      : min !== undefined
        ? `не менее ${min} ${suffix}`
        : `не более ${max} ${suffix}`);

  const isFloat: boolean = /^-?\d*\.?\d*$/.test(value as string); // Проверка на число с плавающей точкой
  const parsedValue: number = parseFloat(value as string);

  return (
    value === null || value === undefined || value === '' || // пустое значение допускается
    (isFloat && !isNaN(parsedValue) && (min === undefined || parsedValue >= min!) && (max === undefined || parsedValue <= max!)) ||
    message
  );
}
