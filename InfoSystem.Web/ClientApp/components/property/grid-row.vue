<template>
  <tr @click="linkTo(item)" :class="{ link: item.isComplex }">
    <td>{{ formatKey(item) }}</td>
    <td v-if="item.isComplex">{{ item.displayComplexValue }}</td>
    <property-edit-dialog v-else :item="item" />
    <delete-dialog :remove="remove" />
  </tr>
</template>

<script>
import { mapActions } from 'vuex'
import PropertyEditDialog from '~/components/property/edit-dialog.vue'
import DeleteDialog from '~/components/delete-dialog.vue'
export default {
  props: ['item'],
  components: {
    PropertyEditDialog,
    DeleteDialog
  },
  methods: {
    ...mapActions(['deleteProperty']),
    remove() {
      this.deleteProperty({
        propertyId: this.item.id,
        typeName: this.$route.params.typeName
      })
    },
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
