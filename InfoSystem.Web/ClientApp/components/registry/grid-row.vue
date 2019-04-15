<template>
  <nuxt-link :to="`${$route.params.typeName}/${item.id}`" tag="tr" style="cursor:pointer">
    <td>{{ item.display }}</td>
    <registry-delete-dialog :item="item" />
  </nuxt-link>
</template>

<script>
import RegistryDeleteDialog from '~/components/registry/delete-dialog.vue'
export default {
  props: ['item'],
  components: {
    RegistryDeleteDialog
  }
}
</script>

<style>
</style>
