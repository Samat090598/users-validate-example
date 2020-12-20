<template>
  <div class="formValidation">
    <div class="container">
      <div class="row">
        <div class="col-sm-8 offset-sm-2">
          <div>
            <h2>Vue.js + Vuelidate - Form Validation</h2>
            <form @submit.prevent="handleSubmit">
              <div class="form-group">
                <label for="firstName">Имя</label>
                <input type="text" v-model="user.firstName" id="firstName" name="firstName" class="form-control" :class="{ 'is-invalid': submitted && $v.user.firstName.$error }" />
                <div v-if="submitted && !$v.user.firstName.required" class="invalid-feedback">Имя не заполнено</div>
              </div>
              <div class="form-group">
                <label for="lastName">Last Name</label>
                <input type="text" v-model="user.lastName" id="lastName" name="lastName" class="form-control" :class="{ 'is-invalid': submitted && $v.user.lastName.$error }" />
                <div v-if="submitted && !$v.user.lastName.required" class="invalid-feedback">Фамилия не заполнено</div>
              </div>
              <div class="form-group">
                <label for="email">Email</label>
                <input type="email" v-model="user.email" id="email" name="email" class="form-control" :class="{ 'is-invalid': submitted && $v.user.email.$error }" />
                <div v-if="submitted && $v.user.email.$error" class="invalid-feedback">
                  <span v-if="!$v.user.email.required">Email не заполнен</span>
                  <span v-if="!$v.user.email.email">Неправильный email</span>
                </div>
              </div>
              <div class="form-group">
                <label for="password">Password</label>
                <input type="password" v-model="user.password" id="password" name="password" class="form-control" :class="{ 'is-invalid': submitted && $v.user.password.$error }" />
                <div v-if="submitted && $v.user.password.$error" class="invalid-feedback">
                  <span v-if="!$v.user.password.required">Пароль не заполнен</span>
                  <span v-if="!$v.user.password.minLength">Пароль не должен быть короче 6 символов</span>
                </div>
              </div>
              <div class="form-group">
                <label for="confirmPassword">Подтвердите пароль</label>
                <input type="password" v-model="user.confirmPassword" id="confirmPassword" name="confirmPassword" class="form-control" :class="{ 'is-invalid': submitted && $v.user.confirmPassword.$error }" />
                <div v-if="submitted && $v.user.confirmPassword.$error" class="invalid-feedback">
                  <span v-if="!$v.user.confirmPassword.required">Пароль не заполнен</span>
                  <span v-else-if="!$v.user.confirmPassword.sameAsPassword">Пароли не совпадают</span>
                </div>
              </div>
              <div class="form-group">
                <button class="btn btn-primary">Register</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { required, email, minLength, sameAs } from "vuelidate/lib/validators";
import {mapActions} from 'vuex'

export default {
name: "FormValidation",
  data() {
    return {
      user: {
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        confirmPassword: ""
      },
      submitted: false
    };
  },
  validations: {
    user: {
      firstName: { required },
      lastName: { required },
      email: { required, email },
      password: { required, minLength: minLength(6) },
      confirmPassword: { required, sameAsPassword: sameAs('password') }
    }
  },
  methods: {
    ...mapActions([
       'POST_USER_INFO'
    ]),
    handleSubmit() {
      this.submitted = true;

      // stop here if form is invalid
      this.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }

      // alert("SUCCESS!! :-)\n\n" + JSON.stringify(this.user));

      let user = this.user;
      this.POST_USER_INFO({user: user})
        .then((response) => {
          console.log(response.data);
        });
    }
  }
}
</script>

<style scoped>

</style>