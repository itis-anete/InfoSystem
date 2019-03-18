<template>
  <td class="justify-end layout px-4">
    <v-edit-dialog @click.native.stop lazy persistent ref="attributeDeleteDialog">
      <v-btn flat icon>
        <v-icon small>delete</v-icon>
      </v-btn>
      <template v-slot:input>
        <p class="pt-3 pb-1 ma-0 text-xs-center">Are you sure?</p>
        <v-btn color="error" flat @click="clear">no</v-btn>
        <v-btn color="success" flat @click="remove">yes</v-btn>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  props: ['item'],
  data() {
    return {
      value: this.item.value
    }
  },
  methods: {
    ...mapActions(['deleteAttribute']),
    remove() {
      this.deleteAttribute({
        attributeId: this.item.id,
        typeName: this.$route.params.typeName
      })
      this.clear()
    },
    clear() {
      this.$refs['attributeDeleteDialog'].isActive = false
    }
  }
}
</script>