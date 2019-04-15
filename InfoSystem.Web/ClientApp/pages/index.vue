<template>
  <v-container>
    <v-layout column justify-center align-center>
      <v-flex xs12 sm8 md6>
        <v-card>
          <v-card-title class="headline">Welcome to {{ name }}</v-card-title>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    name: 'InfoSystem'
  }),
  head() {
    return {
      title: 'Home Page'
    }
  }
}
</script>

