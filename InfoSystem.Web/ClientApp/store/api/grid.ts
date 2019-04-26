import axios from 'axios'

export const api = axios.create({
  baseURL: '/api/property'
})

export async function loadHeader(typeName: string): Promise<string> {
  const response = await api.get(`/GetAttributeValue?typeName=${typeName}&attributeName=display`)
  return response.data as string
}
