<template>
  <td class="justify-end layout px-4">
    <v-edit-dialog
      @click.native.stop
      large
      lazy
      persistent
      save-text="delete"
      @save="save"
      @cancel="cancel"
    >
      <v-icon small>delete</v-icon>
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
    save() {
      this.deleteAttribute({
        id: this.item.id,
        typeName: this.$route.params.typeName
      })
    },
    cancel() {}
  }
}
</script>