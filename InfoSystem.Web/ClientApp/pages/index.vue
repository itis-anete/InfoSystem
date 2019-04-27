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


<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator'
@Component({})
export default class Home extends Vue {
  private name = 'InfoSystem'
}
</script>


