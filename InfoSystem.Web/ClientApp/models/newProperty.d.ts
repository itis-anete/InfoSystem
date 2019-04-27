import { Type } from './type'
import { Entity } from './entity'

export interface newProperty {
  key: Type | string
  value: string | Entity
  typeId?: number
  entityId?: number
}
