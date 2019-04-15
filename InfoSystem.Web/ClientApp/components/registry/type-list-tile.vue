<template>
  <div>
    <v-list-tile :key="type.name" :to="`/registries/${type.name}`">
      <v-list-tile-content>
        <v-list-tile-title :class="{ active: isActive(type.name) }" v-html="formatName(type.name)" />
      </v-list-tile-content>
    </v-list-tile>
    <v-divider :key="type.id" />
  </div>
</template>

<script>
export default {
  props: ['type'],
  methods: {
    formatName(name) {
      return `${name.charAt(0).toUpperCase()}${name.slice(1)}s`
    },
    isActive(name) {
      return this.$route.params.typeName == name
    }
  }
}
</script>
