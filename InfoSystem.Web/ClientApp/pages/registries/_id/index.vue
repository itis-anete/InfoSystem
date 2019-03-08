<template>
  <v-card v-if="entities">
    <registry-grid v-if="entities" :headers="headers" :items="entities"></registry-grid>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
import RegistryGrid from '~/components/RegistryGrid.vue'
export default {
  name: 'Child',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    RegistryGrid
  },
  data() {
    return {
      headers: [{ text: 'Id', sortable: false }, { text: '', sortable: false }]
    }
  },
  computed: {
    ...mapGetters(['entities/entities']),
    id() {
      return this.$route.params.id
    }
  },
  watch: {
    id() {
      this.$store.dispatch('entities/getEntities', this.id)
    }
  },
  created() {
    this.$store.dispatch('entities/getEntities', this.$route.params.id)
  }
}
</script>

<style scoped>
</style>
