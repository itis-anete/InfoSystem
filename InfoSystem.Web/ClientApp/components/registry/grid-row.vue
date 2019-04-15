<template>
  <nuxt-link :to="`${$route.params.typeName}/${item.id}`" tag="tr" style="cursor:pointer">
    <td>{{ item.display }}</td>
    <delete-dialog :remove="remove" />
  </nuxt-link>
</template>

<script>
import DeleteDialog from '~/components/delete-dialog.vue'
import { mapActions } from 'vuex'
export default {
  props: ['item'],
  components: {
    DeleteDialog
  },
  methods: {
    ...mapActions(['deleteEntity']),
    remove() {
      this.deleteEntity(this.item.id)
    }
  }
}
</script>

<style>
</style>
