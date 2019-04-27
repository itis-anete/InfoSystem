<template>
  <v-list-tile :to="item.link" router exact>
    <v-list-tile-action>
      <v-tooltip right>
        <template v-slot:activator="{ on }">
          <v-icon v-on="on" v-html="item.icon" :class="{ active: isActive && index == 1 }" />
        </template>
        <span>{{ item.title }}</span>
      </v-tooltip>
    </v-list-tile-action>
  </v-list-tile>
</template>


<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'
import { MenuItem } from '../../models/menuItem'

@Component({
  name: 'MenuListTile'
})
export default class extends Vue {
  @Prop() item!: MenuItem
  @Prop() index!: Number

  get isActive() {
    return this.$route.path.includes('registries')
  }
}
</script>

<style scoped>
.active {
  color: #52a8b6 !important;
}
</style>