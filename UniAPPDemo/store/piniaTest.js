import {
	defineStore
} from "pinia";
export const useTestStore = defineStore("test", {
	state: () => ({
		count: 0,
		name: "test",
	}),
	actions: {
		increment() {
			this.count++;
		},
		decrement() {
			this.count--;
		},
		setName(name) {
			this.name = name;
		},
	},
	getters: {
		doubleCount() {
			return this.count * 2;
		},
	},
	persist: {
		enabled: true,
		strategies: [{
			key: "test",
			storage: sessionStorage,
		}, ],
	},
});