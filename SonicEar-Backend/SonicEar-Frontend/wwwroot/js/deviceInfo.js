const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"
const measurementurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement/device="

Vue.createApp({
    data() {
        return {
            item: null,
            measurements: [],
            paginatedItems: [],
            errormessage: null,
            id: null,
            pageAmount: null,
            rowsPerPage: 6,
            currentPage: 1
            
        }
    },
    async created() {
        await this.getItems();
        this.pageAmount = Math.ceil(this.measurements.length / this.rowsPerPage)
        await this.DisplayList()
    },
    methods: {
        async getItems() {
            try {
                const urlParams = new URLSearchParams(location.search)
                this.id = urlParams.get('id')

                const response = await axios.get(baseurl + urlParams.get('id'))
                const measurementresponse = await axios.get(measurementurl + this.id)

                this.item = await response.data
                this.measurements = await measurementresponse.data
                

            } catch (ex) {
                this.errormessage = ex.message
            }
        },
        async DisplayList() {
            let page = this.currentPage - 1;
            let start = this.rowsPerPage * page;
            let end = start + this.rowsPerPage;
            this.paginatedItems = this.measurements.slice(start, end);

        },

        setPage(number) {
            if (number < 1) number = 1;
            if (number > this.pageAmount) number = this.pageAmount;
            this.currentPage = number;
            this.DisplayList();
        }
    }
}).mount("#app")