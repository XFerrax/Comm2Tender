import { useAuthStore } from '~/store/auth.store'

export enum HttpQueryType
{
  get = 'GET',
  post = 'POST',
}

export enum DateType
{
  date,
  month,
}

export interface ILengthRule
{
  min?: number,
  max?: number,
}

export interface FloatValidatorOptions {
  value: string | number | null | undefined;
  rule?: { min?: number | undefined; max?: number | undefined };
  short?: boolean;
  text?: string;
  suffix?: string;
}

export function BuildQuery(queryType: HttpQueryType, postBody?: any)
{
  const authStore = useAuthStore()
  if(queryType == HttpQueryType.post) {
    return {
      method: queryType.toString(),
      headers: 
      {
         'Content-Type': 'application/json', 
         'Authorization': `Bearer ${computed(()=>authStore.accessToken)}`,
      },
      body: JSON.stringify(postBody)
    }
  }
  else {
    return {
      method: queryType.toString(),
      headers: 
      {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${authStore.accessToken}`,
        
      },
    }
  }
}

export function convertDateStringToISOString(date: string, type: DateType) {
  if (!date) return ''

  let day = ''
  let month = ''
  let year = ''

  const s = date.split('.')

  if (type === DateType.month) {
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

export function isValidDate(d?: Date) {
  return d instanceof Date && d.getFullYear() >= 1000
}