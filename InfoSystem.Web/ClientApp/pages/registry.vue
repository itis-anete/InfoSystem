<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card v-if="entities">
        <registry-grid :headers="headers" :items="entities"></registry-grid>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import RegistryGrid from '../components/RegistryGrid.vue'
export default {
  components: {
    RegistryGrid
  },
  data() {
    return {}
  },
  created() {
    this.$store.dispatch('getEntities', 1)
  },
  methods: {
    ...mapActions(['getEntities'])
  },
  computed: {
    ...mapGetters(['entities']),
    headers() {
      var a = []
      if (this.entities.length != 0) {
        var entityProperties = Object.keys(this.entities[0])
        entityProperties.forEach(x => a.push({ text: x, value: x }))
        a[0].sortable = false
        a.push({ text: '', sortable: false })
      }
      return a
    }
  }
}
</script>
