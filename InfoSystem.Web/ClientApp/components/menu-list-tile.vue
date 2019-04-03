<template>
  <v-list-tile :to="getProperty(item, 'link')" router exact>
    <v-list-tile-action>
      <v-tooltip right>
        <template v-slot:activator="{ on }">
          <v-icon
            v-on="on"
            v-html="getProperty(item, 'icon')"
            :class="{ active: isActive && index==1 }"
          ></v-icon>
        </template>
        <span>{{getProperty(item, 'title')}}</span>
      </v-tooltip>
    </v-list-tile-action>
  </v-list-tile>
</template>

<script>
export default {
  props: ['item', 'index'],
  methods: {
    getProperty(item, key) {
      return item.find(x => x.key == key).value
    }
  },
  computed: {
    isActive() {
      return this.$route.path.includes('registries')
    }
  }
}
</script>

<style scoped>
.active {
  color: #52a8b6 !important;
}
</style>