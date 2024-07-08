import * as helpers from '~/utils/helpers'

export const required = (value) => !!value || 'Обязательное поле'

export const email = (value) => {
  const pattern = /.+@.+\..+/i
  return !value || pattern.test(value) || 'Проверьте правильность заполнения'
}

export const date = (value, type) => {
  if (!type) {
    type = 'date'
  }
  return !value || helpers.convertDateStringToISOString(value, type).length > 0 || 'Некорректная дата'
}

export function length(value, rule, message) {
  if (!rule) {
    return 'Неправильно установлено правило проверки'
  }
  const length = value.length
  const min = rule.min
  const max = rule.max

  if (!message) {
    message =
      'Количество символов должно быть ' +
      (min !== undefined && max !== undefined
        ? min === max
          ? `${min}`
          : `от ${min} до ${max}`
        : min !== undefined
        ? `не менее ${min}`
        : `не более ${max}`)
  }

  return (
    !value || // отсутствующее значение допускается, так как обязательность проверяется required
    ((min === undefined || length >= min) && (max === undefined || length <= max)) ||
    message
  )
}

export function phone(value, message) {
  return length(value, { min: 16, max: 16 }, message)
}

export function int(value, rule, short) {
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
  const isInteger = /^(-|\+)?([0-9]+|Infinity)$/.test(value)
  const length = value == null ? 0 : value.length
  value = parseInt(value)

  return (
    length === 0 || // отсутствующее значение допускается, так как обязательность проверяется required
    (isInteger && isNaN(value) === false && (min === undefined || value >= min) && (max === undefined || value <= max)) ||
    message
  )
}

export function float({ value, rule = { min: undefined, max: undefined }, short = false, text = 'Требуется число', suffix = '' }) {
  if (typeof value === 'string') {
    value = value.replace(',', '.')
  }

  const min = rule.min
  const max = rule.max

  const message =
    (short ? '' : `${text} `) +
    (min !== undefined && max !== undefined
      ? min === max
        ? `${min}`
        : `от ${min} до ${max}`
      : min !== undefined
      ? `не менее ${min} ${suffix}`
      : `не более ${max} ${suffix}`)

  const isFloat = /^(-|\+)?([0-9]+(\.[0-9]+)?|Infinity)$/.test(value)
  const length = value == null ? 0 : value.length
  value = parseFloat(value)

  return (
    length === 0 || // отсутствующее значение допускается, так как обязательность проверяется required
    (isFloat && isNaN(value) === false && (min === undefined || value >= min) && (max === undefined || value <= max)) ||
    message
  )
}
