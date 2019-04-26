export interface Property {
  id: number
  key: string
  value: string
  typeId: number
  entityId: number
  isComplex: boolean
  displayComplexValue: string
  typeName?: string
}
