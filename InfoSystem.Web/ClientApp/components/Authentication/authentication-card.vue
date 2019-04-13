<template>
  <div>
    <v-card class="elevation-1 pa-3">
      <v-card-text>
        <div class="layout column align-center">
          <img src="../../assets/logo.png" alt="Vue Material Admin" width="120" height="120" />
          <h1 class="flex my-4 primary--text">InfoSystem</h1>
        </div>
        <v-form>
          <v-text-field
            append-icon="person"
            outline
            v-model="username"
            label="Username"
            @keyup.enter="submit"
            :error-messages="nameErrors"
            @input="$v.username.$touch()"
            @blur="$v.username.$touch()"
          ></v-text-field>
          <v-text-field
            outline
            v-model="password"
            :append-icon="showPassword ? 'visibility_off' : 'visibility'"
            :type="showPassword ? 'text' : 'password'"
            label="Password"
            @keyup.enter="submit"
            @click:append="showPassword = !showPassword"
            :error-messages="passwordErrors"
            @input="$v.password.$touch()"
            @blur="$v.password.$touch()"
          ></v-text-field>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-btn large color="primary" :disabled="$v.$invalid" block @click="submit">{{ buttonText }}</v-btn>
      </v-card-actions>
    </v-card>
    <v-card flat class="mt-3 card_switch">
      {{ switchText }}
      <a @click="$emit('input', !value)">{{ switchLink }}</a>
    </v-card>
  </div>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required, minLength, email } from 'vuelidate/lib/validators'
export default {
  props: ['value', 'buttonText', 'switchText', 'switchLink', 'onSubmit'],
  mixins: [validationMixin],
  validations: {
    password: { required, minLength: minLength(6) },
    username: { required }
  },
  data() {
    return {
      showPassword: false,
      password: '',
      username: ''
    }
  },
  computed: {
    passwordErrors() {
      const errors = []
      if (!this.$v.password.$dirty) return errors
      !this.$v.password.minLength && errors.push('Password must be at most 6 characters long')
      !this.$v.password.required && errors.push('Password is required.')
      return errors
    },
    nameErrors() {
      const errors = []
      if (!this.$v.username.$dirty) return errors
      !this.$v.username.required && errors.push('Username is required.')
      return errors
    }
  },
  methods: {
    submit() {
      this.$v.$touch()
      if (!this.$v.$invalid) {
        this.onSubmit(this.username, this.password)
        this.clear()
      }
    },
    clear() {
      this.$v.$reset()
      this.username = ''
      this.password = ''
    }
  }
}
</script>

<style scoped>
.registration_error {
  margin-top: 20px;
}
.registration_error_message {
  margin-top: 20px;
  text-align: center;
  color: #ff5252;
  margin-bottom: 0;
}
.card {
  border-radius: 5px;
}
.card_switch {
  padding: 25px 15px;
  text-align: center;
}
a {
  text-decoration: none;
}
</style>