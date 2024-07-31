export function getListRequest({ pagination, search, sort, filter, dateTime, isActual }) {
  if (!pagination) {
    pagination = { page: 1, itemsPerPage: -1 }
  }
  if (!sort) {
    sort = []
  }
  if (!search) {
    search = ''
  }
  if (!isActual) {
    isActual = false
  }

  const result = {
    page: pagination.page,
    size: pagination.itemsPerPage,
    search: search.trim(),
    sort,
    filter,
    dateTime,
    isActual,
  }

  if (pagination.sortBy != null && pagination.sortDesc != null) {
    pagination.sortBy.forEach((item, index) => {
      // pagination.sortException - исключения сортировки, когда в одном столбце таблицы находятся данные из нескольких полей объекта
      const sortException = Array.isArray(pagination.sortException) ? pagination.sortException.find((x) => x.name === item) : false
      if (sortException) {
        // расширяем массив сортировки, необходимыми столбцами, заменяя виртуальный параметр
        result.sort.push(...sortException.sortBy.map((value) => ({ prop: value, isDesc: pagination.sortDesc[index] })))
      } else {
        // исключения для данного параметра сортировки отсутсвуют
        result.sort.push({ prop: item, isDesc: pagination.sortDesc[index] })
      }
    })
  }

  return result
}

export function getPersonDocumentString(person) {
  return `${person.documentType ? person.documentType.name + ' ' : ''}${person.documentSeries.length > 0 ? person.documentSeries + ' ' : ''}${
    person.documentNumber.length > 0 ? person.documentNumber + ' ' : ''
  }${person.documentDate || person.documentAdd.length > 0 ? 'выдан ' : ''}${
    person.documentDate ? convertDateISOStringToString(person.documentDate) + ' ' : ''
  }${person.documentAdd.length > 0 ? person.documentAdd : ''}`
}

export function sleepInternal(ms) {
  return new Promise((resolve) => setTimeout(resolve, ms))
}

// await this.$helpers.sleep(500)
export async function sleep(ms) {
  console.log(`Пауза ${ms} мс...`)
  await this.sleepInternal(ms)
  console.log('Пауза завершена')
}

export function toastSuccess(payload) {
  Vue.toasted.show(payload.message, {
    duration: 5000,
    // theme: 'bubble',
    type: 'success',
    icon: 'check_circle',
  })
}

export function toastInfo(payload) {
  Vue.toasted.show(payload.message, {
    duration: 5000,
    // theme: 'bubble',
    type: 'info',
    icon: 'warning',
  })
}

export function toastError(payload) {
  Vue.toasted.show(payload.message, {
    duration: 10000,
    // theme: 'bubble',
    type: 'error',
    icon: 'error',
  })
}

export function convertDateTimeISOStringToString(dateTime, wos) {
  if (!dateTime) return ''
  const temp = dateTime.split('T')
  const [year, month, day] = temp[0].split('-')
  // секунды могут быть как целые так и дробные
  // "2021-01-20T14:45:42+00:00"
  // "2021-01-20T14:45:42.1535061+00:00"
  const [hour, minute, second] = temp[1].split('.')[0].split('+')[0].split(':')
  return `${day}.${month}.${year} ${hour}:${minute}${wos === true ? '' : `:${second}`}`
}

export function convertDateISOStringToString(date, type) {
  if (!date) return ''

  const [year, month, day] = date.split('T')[0].split('-')

  if (type === 'month') {
    return `${month}.${year}`
  }

  return `${day}.${month}.${year}`
}

export function dateToISOString(dateTime) {
  if (!dateTime) return ''

  return [dateTime.getFullYear(), (dateTime.getMonth() + 1).toString().padStart(2, '0'), dateTime.getDate().toString().padStart(2, '0')].join('-')
}

export function convertDateStringToISOString(date, type) {
  if (!date) return ''

  let day = ''
  let month = ''
  let year = ''

  const s = date.split('.')

  if (type === 'month') {
    // MM.yyyy
    day = '01'
    month = s[0]
    year = s[1]
  } else {
    // dd.MM.yyyy
    day = s[0]
    month = s[1]
    year = s[2]
  }

  const result = `${year}-${month}-${day}T00:00:00`
  // const result = `${year}-${month}-${day}`
  const test = new Date(result)

  if (isValidDate(test)) {
    return result
  }
  return ''
}

export function getPercentOrValueString(o) {
  if (!o) return ''

  return o.percent !== null ? `${o.percent * 100} %` : `${o.value} ₽`
}

export function periodToString(dateFrom, dateTo, type) {
  return (
    (dateFrom ? `с ${convertDateISOStringToString(dateFrom, type)}` : '') +
    (dateTo ? ` ${type === 'month' ? 'по' : 'до'} ${convertDateISOStringToString(dateTo, type)}` : '')
  )
}

export function convertUTCDateToLocalDate(date) {
  const newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000)

  const offset = date.getTimezoneOffset() / 60
  const hours = date.getHours()

  newDate.setHours(hours - offset)

  return newDate
}

export function getDateMonthBegin(date) {
  return new Date(date.getFullYear(), date.getMonth(), 1)
}

export function getDateMonthEnd(date) {
  return new Date(date.getFullYear(), date.getMonth() + 1, 0)
}

export function getDatePreviousMonthBegin(date) {
  return new Date(date.getFullYear(), date.getMonth() - 1, 1)
}

export function getDatePreviousMonthEnd(date) {
  return new Date(date.getFullYear(), date.getMonth(), 0)
}

export function getDateYearBegin(date) {
  return new Date(date.getFullYear(), 0, 1)
}

export function getDateYearhEnd(date) {
  return new Date(date.getFullYear(), 11, 31)
}

export function isValidDate(d) {
  return d instanceof Date && !isNaN(d) && d.getFullYear() >= 1000
}

export function getMonthNameByIndex(index) {
  // Значение, возвращённое методом getMonth(), является целым числом от 0 до 11
  switch (index) {
    case 0:
      return 'Январь'
    case 1:
      return 'Февраль'
    case 2:
      return 'Март'
    case 3:
      return 'Апрель'
    case 4:
      return 'Май'
    case 5:
      return 'Июнь'
    case 6:
      return 'Июль'
    case 7:
      return 'Август'
    case 8:
      return 'Сентябрь'
    case 9:
      return 'Октябрь'
    case 10:
      return 'Ноябрь'
    case 11:
      return 'Декабрь'
  }
  return ''
}

export function getFloat(value) {
  if (typeof value === 'string') {
    return parseFloat(value.trim().replace(',', '.'))
  }
  return value
}

export function getInt(value) {
  if (typeof value === 'string') {
    return parseInt(value.trim())
  }
  return value
}

export function getPhone(value) {
  if (typeof value === 'string') {
    return value.trim().replaceAll('-', '')
  }
  return value
}

export function getPhoneCounter(value) {
  if (typeof value === 'string') {
    return value.replaceAll('+7', '').replaceAll('-', '').length
  }
  return 0
}

export function phoneInputFocus(value) {
  if (typeof value === 'string' && value.length === 0) {
    return '+7-'
  }
  return value
}

export function phoneInputBlur(value) {
  if (typeof value === 'string' && value.trim().length <= 3) {
    return ''
  }
  return value
}

export function getDateToday() {
  const dateNow = new Date()
  return new Date(dateNow.getFullYear(), dateNow.getMonth(), dateNow.getDate())
}

export function getFileNameFromHeader(header, defaultName) {
  if (!defaultName) defaultName = 'file'
  if (!header) return defaultName
  let array = header.split(';')
  if (array.length !== 3) return defaultName
  array = array[2].split("'")
  if (array.length !== 3) return defaultName
  return decodeURI(array[2].trim())
}

export function getFile(response, name, isUseContentDisposition) {
  const url = window.URL.createObjectURL(new Blob([response.data]))
  const link = document.createElement('a')
  link.href = url
  link.download = isUseContentDisposition === true ? getFileNameFromHeader(response.headers['content-disposition'], name) : name
  document.body.appendChild(link)
  link.click()
  link.remove()
}