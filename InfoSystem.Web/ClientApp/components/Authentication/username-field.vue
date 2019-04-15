<template>
  <v-text-field
    append-icon="person"
    outline
    v-model="localUsername"
    label="Username"
    @keyup.enter="submit"
    :error-messages="nameErrors"
    @input="v.username.$touch()"
    @blur="v.username.$touch()"
  />
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'
export default {
  props: ['username', 'submit', 'v'],
  mixins: [validationMixin],
  computed: {
    nameErrors() {
      const errors = []
      if (!this.v.username.$dirty) return errors
      !this.v.username.required && errors.push('Username is required.')
      return errors
    },
    localUsername: {
      get() {
        return this.username
      },
      set(value) {
        this.$emit('update:username', value)
      }
    }
  }
}
</script>

<style>
</style>
