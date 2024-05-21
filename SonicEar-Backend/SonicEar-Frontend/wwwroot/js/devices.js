const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
            currentSort: null,
        }
    },
    async created() {
        this.getItems()
    },
    methods: {
        async getItems() {
            try {
                let response = await axios.get(baseurl)

                const urlParems = new URLSearchParams(location.search)

                if (urlParems.has('sortBy')) {
                    this.currentSort = urlParems.get('sortBy')
                    console.log(urlParems.get('sortBy'))
                    response = await axios.get(baseurl + '?sortBy=' + this.currentSort)
                }
              
                this.items = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },
        setSort(sortBy) {
            switch (sortBy) {

                case 'id':
                    if (this.currentSort == 'id_desc') return ''
                    else return '?sortBy=id_desc'
                    break;
                case 'location':
                    if (this.currentSort == 'location_desc') return '?sortBy=location_asc'
                    else return '?sortBy=location_desc'
                    break;
                default:
                    break;

			} 
        }
    }
}).mount("#app")