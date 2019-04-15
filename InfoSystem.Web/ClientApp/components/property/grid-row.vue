<template>
  <tr @click="linkTo(item)" :class="{ link: item.isComplex }">
    <td>{{ formatKey(item) }}</td>
    <td v-if="item.isComplex">{{ item.displayComplexValue }}</td>
    <property-edit-dialog v-else :item="item" />
    <property-delete-dialog :item="item" />
  </tr>
</template>

<script>
import PropertyEditDialog from '~/components/property/edit-dialog.vue'
import PropertyDeleteDialog from '~/components/property/delete-dialog.vue'
export default {
  props: ['item'],
  components: {
    PropertyEditDialog,
    PropertyDeleteDialog
  },
  methods: {
    linkTo(item) {
      if (item.isComplex) this.$router.push(`../${item.key.substring(8)}/${item.value}`)
    },
    formatKey(item) {
      return item.isComplex ? item.key.substring(8) : item.key
    }
  }
}
</script>

<style>
.link {
  cursor: pointer !important;
}
</style>
