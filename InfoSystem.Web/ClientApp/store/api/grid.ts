import { api } from './api'

export async function loadHeader(typeName: string): Promise<string> {
  const response = await api.get(`property/GetAttributeValue?typeName=${typeName}&attributeName=display`)
  return response.data as string
}
