export default defineNuxtPlugin((app) => {

})

const BASE_API_URL = 'http://localhost:5037/api';
export function fetchData(endpoint: string, query: any) {
    return fetch(`${BASE_API_URL}/${endpoint}`, query)
    .then(response => {
        if(!response.ok) {
            return Promise.reject(`Error: ${response.statusText}`)
        }
        return response.json()
    })
}