using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class Import
    {
        [DeserializeAs(Name = "import_id")]
        public int ImportId { get; set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        [DeserializeAs(Name = "style")]
        public string Style { get; set; }

        [DeserializeAs(Name = "import_started")]
        public DateTime? ImportStarted { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "error_message")]
        public string ErrorMessage { get; set; }

        [DeserializeAs(Name = "num_members_updated")]
        public int NumMembersUpdated { get; set; }

        [DeserializeAs(Name = "source_filename")]
        public string SourceFilename { get; set; }

        [DeserializeAs(Name = "fields_updated")]
        public List<Field> FieldsUpdated { get; set; }

        [DeserializeAs(Name = "num_fields_added")]
        public int NumFieldsAdded { get; set; }

        [DeserializeAs(Name = "import_finished")]
        public DateTime? ImportFinished { get; set; }

        [DeserializeAs(Name = "groups_updated")]
        public List<Group> GroupsUpdated { get; set; }

        [DeserializeAs(Name = "num_skipped")]
        public int NumSkipped { get; set; }

        [DeserializeAs(Name = "num_duplicates")]
        public int NumDuplicates { get; set; }
    }
}
