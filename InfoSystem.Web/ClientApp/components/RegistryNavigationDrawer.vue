<template>
  <v-navigation-drawer style="margin-top: 1px">
    <v-list two-line subheader>
      <v-subheader>Entities</v-subheader>
      <v-divider></v-divider>
      <template v-for="(type, index) in types">
        <v-list-tile :key="type.name" :to="'/registries/'+type.id" router exact>
          <v-list-tile-action>
            <v-icon>{{icons[type.id-1]}}</v-icon>
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
export default {
  props: ['types'],
  data: () => ({
    icons: ['local_grocery_store', 'toc']
  })
}
</script>
