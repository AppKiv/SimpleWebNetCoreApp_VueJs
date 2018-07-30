<template>
  <div id="app">
    <!--img src="./assets/logo.png"-->
    <rwv-header></rwv-header>
    <table width = "100%">
      <tr>
        <td width = "80%">
          <router-view :key="$route.fullPath"></router-view>
        </td>
        <td>
          <rwv-tag></rwv-tag>
        </td>
      </tr>
    </table>
    <rwv-footer></rwv-footer>
  </div>
</template>

<script>
import RwvHeader from '@/components/TheHeader'
import RwvFooter from '@/components/TheFooter'
import RwvTag from '@/components/tagView'
export default {
  name: 'App',
  components: {
    RwvHeader,
    RwvFooter,
    RwvTag
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
