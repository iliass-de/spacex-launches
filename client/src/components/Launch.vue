<template>
  <ag-grid-vue
    class="ag-theme-alpine"
    style="height: 500px"
    :columnDefs="columnDefs.value"
    :rowData="rowData.value"
    :defaultColDef="defaultColDef"
    rowSelection="multiple"
    animateRows="true"
    @cell-clicked="cellWasClicked"
    @grid-ready="onGridReady"
  >
  </ag-grid-vue>
 </template>
 
 <script>
 import { AgGridVue } from "ag-grid-vue3";  
 import { reactive, onMounted, ref } from "vue";
 
 import "ag-grid-community/styles/ag-grid.css"; 
 import "ag-grid-community/styles/ag-theme-alpine.css"; 
 
 export default {
  name: "App",
  components: {
    AgGridVue,
  },
  setup() {
    const gridApi = ref(null); 
 
    const onGridReady = (params) => {
      gridApi.value = params.api;
    };
 
    const rowData = reactive({}); 
 
 
    const columnDefs = reactive({
      value: [
           { headerName: "Name", field: "name" },
           { headerName: "Fleight number", field: "flight_number" },
           { headerName: "Details", field: "details" }
      ],
    });
 
    // DefaultColDef sets props common to all Columns
    const defaultColDef = {
      sortable: true,
      filter: true,
      flex: 1
    };
 
    // load data from server
    onMounted(() => {
      fetch("https://localhost:7226/launchApi/launches")
        .then((result) => result.json())
        .then((remoteRowData) => (rowData.value = remoteRowData));
    });
 
    return {
      onGridReady,
      columnDefs,
      rowData,
      defaultColDef,
      cellWasClicked: (event) => { 
        console.log(event);
      }
    };
  },
 };
 </script>
 
 <style lang="scss"></style>