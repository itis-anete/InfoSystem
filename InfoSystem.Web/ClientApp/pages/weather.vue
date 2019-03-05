<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card>
        <v-data-table :headers="headers" :items="weather" class="elevation-1">
          <template v-slot:items="props">
            <td>{{ props.item.dateFormatted }}</td>
            <td class="text-xs-center">{{ props.item.temperatureC }}</td>
            <td class="text-xs-center">{{ props.item.temperatureF }}</td>
            <td class="text-xs-center">{{ props.item.summary }}</td>
          </template>
        </v-data-table>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  data() {
    return {
      headers: [
        {
          text: "Date",
          align: "left",
          sortable: false,
          value: "name"
        },
        { text: "Temperature C", value: "temperatureC" },
        { text: "Temperature F", value: "temperatureF" },
        { text: "Summary", value: "summary" }
      ]
    };
  },
  created() {
    this.$store.dispatch("getWeather");
  },
  methods: {
    ...mapActions(["getWeather"])
  },
  computed: {
    ...mapGetters(["weather"])
  }
};
</script>
