//-----------------------------------------------------
// @description 返回grid的(可见的)所有行给后端导出Excel用
// @param {string} table    表格ID
// @returns rows
// @author 肖峰
//------------------------------------------------------
function getGridDataToExcelExport(table) {
    var allRows = $("#" + table).datagrid("getRows");
    return allRows;
}

//-----------------------------------------------------
// @description 返回grid的所有列
// @param {string} table    表格ID
// @returns rows
// @author 肖峰
function getGridColumnFields(table) {
    var allCols = $("#" + table).datagrid("getColumnFields");
    return allCols;
}

//-----------------------------------------------------
// @description 返回grid的所有列的选项title、列宽等
// @param {string} table    表格ID
// @returns rows
// @author 肖峰
function getGridColumnFieldsOptions(table) {
    var allColsTitle = $("#" + table).datagrid("options").columns;
    return allColsTitle;
}
