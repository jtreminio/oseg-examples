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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val automationRuleCreateUpdatePayload = AutomationRuleCreateUpdatePayload(
            name = "Add label on message create event",
            description = "Add label support and sales on message create event if incoming message content contains text help",
            eventName = AutomationRuleCreateUpdatePayload.EventName.messageCreated,
            active = null,
        )

        try
        {
            val response = AutomationRuleApi().addNewAutomationRuleToAccount(
                accountId = null,
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
