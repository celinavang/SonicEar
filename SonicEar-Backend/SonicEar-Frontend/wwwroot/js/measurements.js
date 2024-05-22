const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
            currentSort: null,
            searchQuery: "",
            filteredItems: []
        }
    },
     async created() {
        await this.getItems();
        this.filteredItems = this.items;
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

                this.items = await response.data;
                this.filteredItems = this.items;
            } catch (ex) {
                alert(ex.message)
            }
        },
        setSort(sortBy) {
            let sortParam = "";
            switch (sortBy) {

                case 'id':
                    if (this.currentSort == 'id_desc') return ''
                    else return '?sortBy=id_desc'
                    break;
                case 'location':
                    if (this.currentSort == 'location_desc') return '?sortBy=location_asc'
                    else return '?sortBy=location_desc'
                    break;
                case 'time':
                    if (this.currentSort == 'time_desc') return '?sortBy=time_asc'
                    else return '?sortBy=time_desc'
                    break;
                case 'measurement':
                    if (this.currentSort == 'noise_desc') return '?sortBy=noise_asc'
                    else return '?sortBy=noise_desc'
                    break;
                default:
                    break;
            }
            this.currentSort = sortParam;
            this.getItems();
        },
        getColor(level) {
            if (level < 10) {
                return '#99c0d1'
            } else if (level < 20) {
                return '#70a18b'
            } else if (level < 30) {
                return '#9db17e'
            } else if (level < 40) {
                return '#f0c581'
            } else if (level < 50) {
                return '#dc8c5b'
            } else if (level < 60) {
                return '#d87855'
            } else { return '#c94b3a' }
        },
        },

        search() {
            const query = this.searchQuery.toLowerCase();
            this.filteredItems = this.items.filter(item =>
                item.device.location.toLowerCase().includes(query) ||
                item.timeStamp.toLowerCase().includes(query)
            )
        }
    }
}).mount("#app")