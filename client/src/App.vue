<template>
  <h1>Launches overview</h1>
  <Launch/>
</template>

<script>
import Launch from './components/Launch.vue'

export default {
  name: 'App',
  components: {
    Launch
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
