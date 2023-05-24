
<template>

  <Modal 
     v-model:visible="data.modelIsVisible.value"
      title="Details"
      type="clean"
  >
    <h2>Details</h2>
    <b> {{ data.singleLaunch.value.mission_name }}</b>
    <div> 
          {{ 
              data.singleLaunch.value.details != null 
              ? data.singleLaunch.value.details 
              : "(no details are available)"  
          }}
    </div>
  </Modal>
  <div> Click an item to view details.</div>
  <ag-grid-vue
    class="ag-theme-alpine"
    style="height: 500px"
    :columnDefs="columnDefs.value"
    :rowData="data.rowData.value"
    :defaultColDef="defaultColDef"
    rowSelection="multiple"
    animateRows="true"
    @cell-clicked="clickedCell"
    @grid-ready="onGridReady"
  >
  </ag-grid-vue>

 </template>
 
 <script>
 import { AgGridVue } from "ag-grid-vue3";  
 import { reactive, onMounted, ref, unref } from "vue";
 import { Modal } from 'usemodal-vue3';
 import "ag-grid-community/styles/ag-grid.css"; 
 import "ag-grid-community/styles/ag-theme-alpine.css"; 
 
 export default {
  name: "App",
  components: {
    AgGridVue,
    Modal
  },
  setup() {
    const gridApi = ref(null); 
    const data = {
      launchId : ref(null),
      singleLaunch: ref(null),
      rowData : ref(null),
      modelIsVisible: ref(false)
    };
 
    const onGridReady = (params) => {
      gridApi.value = params.api;
    };
  
    const columnDefs = reactive({
      value: [
           { headerName: "Name", field: "name" },
           { headerName: "Fleight number", field: "flight_number" },
           { headerName: "Date", field: "date_utc" }
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
        .then((remoteRowData) => (data.rowData.value = remoteRowData));
    });

    async function getSingleLaunch() {
      const launchId = unref(data.launchId);
      console.log(launchId);
      await fetch(`https://localhost:7226/launchApi/launch/${launchId}`)
      .then((result) => result.json())
      .then((response) => (data.singleLaunch.value = response));
       data.modelIsVisible.value = true;
    }
 
    return {
      onGridReady,
      data,
      columnDefs,
      defaultColDef,
      clickedCell: (event) => { 
        data.launchId.value = event.data.flight_number;
        getSingleLaunch();
      },
      getSingleLaunch
    };
  },
 };
 </script>
 
 <style>
.modal-vue3-body{
  background-color: #fff;
  padding: 20px;
  border-radius: 4px;
}
.ag-header-cell-text{
  margin-left: 10em;
}

</style>