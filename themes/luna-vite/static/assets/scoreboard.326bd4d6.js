import{c as f}from"./base.29aca91b.js";import{_ as m,d as p}from"./duration.21bcce5f.js";function g(n){let t=[...n];for(let s=0;s<n.length;s++)t[s]=n.slice(0,s+1).reduce(function(o,e){return o+e});return t}function h(n,t){let s={title:{left:"center",text:n==="teams"?m("Top 10 Teams"):m("Top 10 Users")},tooltip:{trigger:"axis",axisPointer:{type:"cross"}},legend:{type:"scroll",orient:"horizontal",align:"left",bottom:35,data:[]},toolbox:{feature:{dataZoom:{yAxisIndex:"none"},saveAsImage:{}}},grid:{containLabel:!0},xAxis:[{type:"time",boundaryGap:!1,data:[]}],yAxis:[{type:"value"}],dataZoom:[{id:"dataZoomX",type:"slider",xAxisIndex:[0],filterMode:"filter",height:20,top:35,fillerColor:"rgba(233, 236, 241, 0.4)"}],series:[],textStyle:{fontFamily:"sans-serif"}};const o=Object.keys(t);for(let e=0;e<o.length;e++){const r=[],l=[];for(let a=0;a<t[o[e]].solves.length;a++){r.push(t[o[e]].solves[a].value);const i=p(t[o[e]].solves[a].date);l.push(i.toDate())}const d=g(r);let u=l.map(function(a,i){return[a,d[i]]});s.legend.data.push(t[o[e]].name);const c={name:t[o[e]].name,type:"line",label:{normal:{position:"top"}},itemStyle:{normal:{color:f(t[o[e]].name+t[o[e]].id)}},data:u};s.series.push(c)}return s}export{g as c,h as g};
