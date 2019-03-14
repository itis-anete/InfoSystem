<template>
  <v-navigation-drawer style="margin-top: 81px" fixed :class="{left: drawer}" width="250">
    <v-list two-line subheader>
      <v-subheader>Entity Types
        <v-spacer></v-spacer>
        <new-type-dialog></new-type-dialog>
      </v-subheader>
      <v-divider></v-divider>
      <template v-for="(type, index) in types">
        <v-list-tile :key="type.name" :to="'/registries/'+type.id" router exact>
          <v-list-tile-action>
            <v-icon>{{icons[type.name.toLowerCase()]}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title v-text="`${type.name}s`"/>
          </v-list-tile-content>
        </v-list-tile>
        <v-divider :key="type.id"></v-divider>
      </template>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import NewTypeDialog from './new-type-dialog.vue'
import { mapGetters } from 'vuex'
export default {
  components: {
    NewTypeDialog
  },
  props: ['types'],
  data: () => ({
    icons: { market: 'local_grocery_store', product: 'toc' }
  }),
  computed: {
    ...mapGetters(['drawer'])
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
