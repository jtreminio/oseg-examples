package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AddNewAutomationRuleToAccountExample
{
    fun addNewAutomationRuleToAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val automationRuleCreateUpdatePayload = AutomationRuleCreateUpdatePayload(
            name = "Add label on message create event",
            description = "Add label support and sales on message create event if incoming message content contains text help",
            eventName = AutomationRuleCreateUpdatePayload.EventName.messageCreated,
            actions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "action_name": "add_label",
                        "action_params": [
                            "support"
                        ]
                    }
                ]
            """)!!,
            conditions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "attribute_key": "content",
                        "filter_operator": "contains",
                        "query_operator": "nil",
                        "values": [
                            "help"
                        ]
                    }
                ]
            """)!!,
        )

        try
        {
            val response = AutomationRuleApi().addNewAutomationRuleToAccount(
                accountId = 0,
                _data = automationRuleCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AutomationRuleApi#addNewAutomationRuleToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AutomationRuleApi#addNewAutomationRuleToAccount")
            e.printStackTrace()
        }
    }
}
