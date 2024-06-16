export default defineNuxtPlugin((app) => {

})

const BASE_API_URL = 'http://localhost:5037/api';
export async function fetchData(endpoint: string, query: any) {
    try{
        return await fetch(`${BASE_API_URL}/${endpoint}`, query)
    }
    catch {

    }
}