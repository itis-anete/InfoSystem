<template>
  <v-navigation-drawer style="margin-top: 81px" fixed :class="{ left: menu.drawer }" width="250">
    <v-list two-line subheader>
      <v-subheader>
        Entity Types
        <v-spacer></v-spacer>
        <new-type-dialog></new-type-dialog>
      </v-subheader>
      <v-divider></v-divider>
      <type-list-tile v-for="(type, index) in types" :type="type" :key="type.name"></type-list-tile>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import NewTypeDialog from './new/type-dialog.vue'
import TypeListTile from './type-list-tile.vue'
import { mapState } from 'vuex'
export default {
  components: {
    NewTypeDialog,
    TypeListTile
  },
  props: ['types'],
  computed: {
    ...mapState(['menu'])
  }
}
</script>

<style>
.v-small-dialog {
  width: inherit;
}
.left {
  transform: translateX(80px) !important;
  transition: transform 1s linear;
}
</style>
