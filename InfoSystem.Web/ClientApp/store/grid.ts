import * as api from '@/store/api/grid'
import { VuexModule, Module, MutationAction } from 'vuex-module-decorators'
import { Header } from '~/models/header'

@Module({
  name: 'grid',
  stateFactory: true,
  namespaced: true
})
export default class GridModule extends VuexModule {
  headers: Header[] = []
  rowsPerPageItems = [10, 20, 100, { text: 'All', value: -1 }]
  pagination = {
    rowsPerPage: 10
  }

  get Headers() {
    return this.headers
  }
  get RowsPerPageItems() {
    return this.rowsPerPageItems
  }
  get Pagination() {
    return this.pagination
  }

  @MutationAction
  async loadHeaders(typeName: string) {
    const header = await api.loadHeader(typeName)
    return {
      headers: [{ text: header, sortable: false, value: header }, { text: '', sortable: false, value: 'Actions' }] as Header[]
    }
  }

  @MutationAction
  async setPagination(pagination: any) {
    return { pagination: pagination }
  }
}
