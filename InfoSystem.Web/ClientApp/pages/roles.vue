<template>
  <v-container class="pl-0 py-0 ml-0 mt-0" fill-height>
    <v-layout justify-center>
      <v-flex xs6>
        <v-card class="pa-4 mt-4">
          <v-card-title>
            <div class="headline primary--text">Add New Role</div>
          </v-card-title>
          <v-divider></v-divider>
          <v-form>
            <v-text-field v-model="name" :rules="nameRules" label="Name" required></v-text-field>
            <v-checkbox
              v-model="readingAbility"
              label="Can member of this role read information?"
              color="primary"
              required
            ></v-checkbox>
            <v-checkbox
              v-model="writingAbility"
              label="Can member of this role write information?"
              color="primary"
              required
            ></v-checkbox>
            <v-btn :disabled="!valid" color="primary" @click="create">Create</v-btn>
          </v-form>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  data: () => ({
    valid: true,
    name: '',
    nameRules: [v => !!v || 'Name is required'],
    readingAbility: false,
    writingAbility: false
  }),

  methods: {
    ...mapActions(['createRole']),
    create() {
      const role = {
        name: this.name,
        canRead: this.readingAbility,
        canWrite: this.writingAbility
      }
      this.createRole(role)
    }
  }
}
</script>