﻿namespace Entities
{
	/// <summary>
	/// Тип валюты.
	/// </summary>
	public class CurrencyType : EntityBase
	{
		/// <summary>
		/// Название.
		/// </summary>
		public virtual string Name { get; set; }

        /// <summary>
        /// Сокрашенное обозначение
        /// </summary>
        public virtual string ShortName { get; set; }
	}
}