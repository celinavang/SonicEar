const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice"

Vue.createApp({
    data() {
        return {
            allItem:[],
            items: [],
            errormessage: null,
        }
    },
    async created() {
        this.getItems(baseurl)
    },
    methods: {
        async getItems(url) {
            try {
                const response = await axios.get(url)
                this.allItems = await response.data
                this.items = this.allItems
                console.log(this.allItems)
            } catch (ex) {
                alert(ex.message)
            }
        },
        sortById() {
            /*this.items.sort((item1,item2) => item1.id - item2.id)*/
            this.getItems(baseurl + "?sort_by=id")
        },
        sortByLocation() {
            this.getItems(baseurl + "?sort_by=location")
        }
    }
}).mount("#app")